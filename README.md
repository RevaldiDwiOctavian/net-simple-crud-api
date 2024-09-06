# Employee Management API

API ini adalah implementasi dari sistem manajemen karyawan sederhana menggunakan **in-memory storage** yang disimpan dalam bentuk list pada repository. API ini menyediakan fitur untuk melakukan operasi **CRUD (Create, Read, Update, Delete)** pada data karyawan.

## Teknologi yang Digunakan
- **ASP.NET Core** untuk pembuatan API.
- **DTO (Data Transfer Object)** untuk validasi dan transfer data antar lapisan aplikasi.
- **In-memory storage** untuk menyimpan data karyawan selama aplikasi berjalan.
- **Service Layer** untuk mengelola logika bisnis.
- **Logging** menggunakan `ILogger` untuk memantau aktivitas API.

## Fitur

### 1. **GET** `/api/employee`
Mendapatkan daftar semua karyawan.

**Response:**
  ```json
  [
    {
      "EmployeeId": 1,
      "FullName": "John Doe",
      "BirthDate": "01-Jan-1990"
    },
    {
      "EmployeeId": 2,
      "FullName": "Jane Doe",
      "BirthDate": "15-Feb-1985"
    }
  ]
  ```

### 2. **PUT** `/api/employee/{employeeId}`
Memperbarui data karyawan berdasarkan `employeeId`.

**Request Body:**
   ```json
   {
     "FullName": "Alice Smith",
     "BirthDate": "05-Mar-1992"
   }
  ```

**Respon:**
  ```json
  {
    "EmployeeId": 1,
    "FullName": "Alice Smith",
    "BirthDate": "05-Mar-1992"
  }
  ```

### 3. **POST** `/api/employee`
Menambahkan karyawan baru.

**Request Body:**
   ```json
   {
     "EmployeeId": 3,
     "FullName": "Alan Smith",
     "BirthDate": "05-Jun-1990"
   }
  ```

### 3. **DELETE** `/api/employee/{employeeId}`
Menghapus data karyawan berdasarkan `employeeId`.

## Repository

**EmployeeRepository** bertanggung jawab atas penyimpanan dan pengelolaan data karyawan dalam **in-memory storage** menggunakan struktur data `List<Employee>`. Semua operasi terkait penyimpanan, pengambilan, pembaruan, dan penghapusan karyawan dikelola oleh kelas ini. Repository ini juga memanfaatkan **logging** untuk mencatat setiap operasi yang dilakukan.

### Metode di EmployeeRepository:

1. **AddEmployee(Employee employee)**  
   Menambahkan karyawan baru ke dalam list in-memory.
  - Menambahkan objek `Employee` ke dalam list `_employees`.
  - Log informasi bahwa karyawan berhasil ditambahkan.
  - **Return**: Karyawan yang baru saja ditambahkan.

2. **GetAllEmployees()**  
   Mengambil semua data karyawan yang tersimpan.
  - Mengembalikan semua karyawan dalam list `_employees`.
  - Log informasi bahwa data karyawan berhasil diambil.
  - **Return**: Daftar semua karyawan (`List<Employee>`).

3. **CheckExistingEmployee(int employeeId)**  
   Memeriksa apakah karyawan dengan `employeeId` tertentu sudah ada.
  - Mencari karyawan dalam list berdasarkan `employeeId`.
  - **Return**: `true` jika karyawan ditemukan, `false` jika tidak ada.

4. **GetEmployeeById(int employeeId)**  
   Mengambil karyawan berdasarkan ID.
  - Mencari karyawan dalam list menggunakan `employeeId`.
  - Jika karyawan tidak ditemukan, log peringatan akan ditampilkan, dan akan melempar **KeyNotFoundException**.
  - **Return**: Objek `Employee` yang sesuai dengan `employeeId`.

5. **UpdateEmployee(Employee employee)**  
   Memperbarui data karyawan yang ada.
  - Mengambil karyawan berdasarkan `employeeId`.
  - Memperbarui `FullName` dan `BirthDate` dari karyawan yang ditemukan.
  - Log informasi bahwa karyawan berhasil diperbarui.
  - **Return**: Karyawan yang telah diperbarui.

6. **DeleteEmployee(int employeeId)**  
   Menghapus karyawan berdasarkan ID.
  - Mengambil karyawan berdasarkan `employeeId`.
  - Menghapus karyawan dari list `_employees`.
  - Log informasi bahwa karyawan berhasil dihapus.

### Struktur Data Employee
Data karyawan disimpan dalam objek `Employee` yang memiliki atribut berikut:
- **EmployeeId**: ID unik untuk setiap karyawan.
- **FullName**: Nama lengkap karyawan.
- **BirthDate**: Tanggal lahir karyawan dalam format `DateOnly`.

### Logging
**ILogger** digunakan untuk melakukan logging pada setiap operasi yang terjadi dalam `EmployeeRepository`. Setiap penambahan, pengambilan, pembaruan, atau penghapusan karyawan akan dicatat, sehingga memudahkan pelacakan aktivitas sistem.

Berikut adalah contoh pesan log yang dihasilkan:
- **Log Information** saat karyawan ditambahkan:  
  `"Employee {EmployeeId} added successfully."`
- **Log Warning** jika karyawan tidak ditemukan:  
  `"Employee with ID {EmployeeId} not found."`
- **Log Information** saat karyawan diperbarui atau dihapus:  
  `"Employee {EmployeeId} updated successfully."`  
  `"Employee {EmployeeId} deleted."`
