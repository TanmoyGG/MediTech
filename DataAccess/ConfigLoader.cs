﻿using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace MediTech.DataAccess
{
    public sealed class ConfigLoader
    {
        private static readonly Lazy<ConfigLoader> instance = new Lazy<ConfigLoader>(() => new ConfigLoader());
        private readonly XDocument _config;

        private readonly string _configFilePath;

        private ConfigLoader()
        {
            const string configFileName = "config.xml";

            if (IsInDesignMode())
            {
                Console.WriteLine("Running in design mode. Skipping config load.");
                return;
            }

            _configFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName));

            Console.WriteLine("Config file path: " + _configFilePath);


            if (!File.Exists(_configFilePath))
                throw new FileNotFoundException($"Configuration file not found at: {_configFilePath}");

            _config = LoadConfig();

            if (_config == null)
            {
                Console.WriteLine("Failed to load configuration.");
                throw new ConfigurationException("Configuration could not be loaded.");
            }
        }

        public static ConfigLoader Instance => instance.Value;

        public bool IsInDesignMode()
        {
            return AppDomain.CurrentDomain.FriendlyName.Contains("DefaultDomain") ||
                   LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        private XDocument LoadConfig()
        {
            try
            {
                return XDocument.Load(_configFilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Configuration file not found: {_configFilePath}");
                throw new ConfigurationException($"Configuration file not found: {_configFilePath}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration from {_configFilePath}: {ex.Message}");
                throw new ConfigurationException($"Error loading configuration from {_configFilePath}", ex);
            }
        }


        //problem
        public string GetValue(string key)
        {
            var keys = key.Split('/');
            var element = _config.Root;

            foreach (var k in keys)
            {
                element = element.Element(k);
                if (element == null) return null;
            }

            return element.Value;
        }

        public TValue GetValue<TValue>(string key)
        {
            var value = GetValue(key);
            if (value == null) return default;

            try
            {
                return (TValue)Convert.ChangeType(value, typeof(TValue));
            }
            catch (Exception ex)
            {
                throw new ConfigurationException($"Error converting value for key '{key}' to type {typeof(TValue)}",
                    ex);
            }
        }

        // New methods for SMTP Configuration
        public string GetSmtpEmail()
        {
            return GetValue("SMTP/Email");
        }

        public string GetSmtpPassword()
        {
            return GetValue("SMTP/AppPassword");
        }

        public string GetSmtpServer()
        {
            return GetValue("SMTP/SmtpServer");
        }

        public int GetSmtpPort()
        {
            return GetValue<int>("SMTP/Port");
        }

        // Existing methods for database configurations
        //problem
        public string GetSqlServerName()
        {
            return GetValue("SqlServerName");
        }

        public string GetDatabaseName()
        {
            return GetValue("DatabaseName");
        }

        public string GetDatabaseFilePath()
        {
            return GetValue("DatabaseFilePath");
        }

        public string GetUserId()
        {
            return GetValue("UserId");
        }

        public string GetPassword()
        {
            return GetValue("Password");
        }

        //problem
        public string GetConnectionString()
        {
            var serverName = GetSqlServerName();
            var databaseName = GetDatabaseName();
            var databaseFilePath = GetDatabaseFilePath();
            var userId = GetUserId();
            var password = GetPassword();

            if (!string.IsNullOrEmpty(serverName))
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = serverName,
                    InitialCatalog = databaseName,
                    IntegratedSecurity = string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(password)
                };

                if (!builder.IntegratedSecurity)
                {
                    if (string.IsNullOrEmpty(userId))
                        throw new ConfigurationException("User ID is not specified in the configuration.");

                    if (string.IsNullOrEmpty(password))
                        throw new ConfigurationException("Password is not specified in the configuration.");

                    builder.UserID = userId;
                    builder.Password = password;
                }

                return builder.ConnectionString;
            }

            if (!string.IsNullOrEmpty(databaseFilePath))
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"(LocalDB)\MSSQLLocalDB",
                    AttachDBFilename = databaseFilePath,
                    IntegratedSecurity = true
                };

                return builder.ConnectionString;
            }

            throw new ConfigurationException(
                "Either SQL Server name or Database file path must be specified in the configuration.");
        }
    }

    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}