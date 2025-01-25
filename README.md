# MediTech - A Digital Solution for Pharmacy Management

MediTech is a comprehensive pharmacy management system designed to streamline the operations of a pharmacy. From inventory tracking to sales management, this digital solution simplifies complex tasks, ensuring efficiency and accuracy.

---

## Features

### 1. **User Authentication**
   - Secure login for admins and staff.
   - Role-based access control.

   ![Login Page Screenshot](https://github.com/user-attachments/assets/101c1ee3-d4bb-4dd2-a567-7a48ffc22421)
  

### 2. **Inventory Management**
   - Add, update, and delete medicine records.

   ![Inventory Management Screenshot](https://github.com/user-attachments/assets/10d7b997-2326-4497-ba41-7766769e610b)

### 3. **Sales Management**
   - Generate bills and manage transactions.
   - View sales history.

   ![Sales Management Screenshot](https://github.com/user-attachments/assets/a24f5f28-9e8a-45a4-a3df-3e2750863aa6)


### 4. **Reports and Analytics**
   - Daily, weekly, and monthly sales reports.
   - Inventory and sales trends.

   ![Reports Screenshot](https://github.com/user-attachments/assets/72a6e579-4915-405d-aa18-3d0a3c4940f7)


---

## How to Run the Project

### Step 1: Clone or Download the Project
- **Download ZIP**: [MediTech ZIP Folder](https://github.com/TanmoyGG/MediTech/archive/master.zip)
- **Clone Repository**:
  ```bash
  git clone https://github.com/TanmoyGG/MediTech.git
  ```

### Step 2: Unblock Files
Run the following command in PowerShell to unblock all files and subfolders:
```powershell
get-childitem "your file path" -recurse | unblock-file
```

### Step 3: Set Up the Local Database
Create a local database in Visual Studio or JetBrains Rider.

### Step 4: Run the SQL Script
Run the table creation SQL script provided in the repository:
- [SQL Script for Table Creation](https://github.com/TanmoyGG/MediTech/blob/master/Database/SQLQuery.sql)

### Step 5: Insert Admin Data
Manually insert at least one record into the `Admin` table to enable login functionality.

---

## Contributing
Feel free to contribute to MediTech by submitting issues or pull requests. Let’s make pharmacy management better together!

---

## License
This project is licensed under the MIT License. See the [LICENSE](https://github.com/TanmoyGG/MediTech/blob/master/LICENSE) file for details.

---
