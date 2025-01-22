# MyBudget

Welcome to MyBudget! This project is designed to provide an intuitive and efficient solution for managing personal finances. The system leverages the power of modern web development technologies to ensure a seamless user experience.

## Features

- **Personalized Financial Management**: Easily track your income, expenses, and savings.
- **Real-Time Insights**: View interactive dashboards for detailed financial insights.
- **Responsive Design**: Optimized for use on desktops, tablets, and mobile devices.
- **Secure Data Handling**: All data is stored securely in a PostgreSQL database hosted on SaaS Neon.

## Technologies Used
<p align="center">
<img src="https://cdn.intuji.com/2022/06/2048px-.net_logo.png" width=100px height=100px>
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Blazor.png/800px-Blazor.png" width=100px height=100px>
<img src="https://mudblazor.com/_content/MudBlazor.Docs/images/logo.png" width=100px height=100px>
<img src="https://www.bigdatawire.com/wp-content/uploads/2024/04/thumbnail_Neon-Logo-300x163.jpg" width=200px height=100px>
</p>

- **Blazor Server**: For creating dynamic, server-side rendered web applications.
- **.NET Framework 8**: The backbone of the application, ensuring reliability and performance.
- **MudBlazor**: A modern UI component library for Blazor applications.
- **PostgreSQL**: A robust relational database for storing user data.
- **SaaS Neon**: A secure and scalable platform for hosting the database.

## Getting Started

### Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [MudBlazor](https://mudblazor.com/getting-started/installation#online-playground)
- [PostgreSQL](https://www.postgresql.org/)
- [Neon Account](https://neon.tech/) (Optional)
- A modern web browser (e.g., Chrome, Edge, or Firefox)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repo/personal-finance-control.git
   cd personal-finance-control
   ```

2. Set up the PostgreSQL database:

   - Create a database in your Neon account
     or
   - Create a local database for development
  

3. Configure the application:

   - Update the `appsettings.json` file with your PostgreSQL connection string.
   - Apply the initial migration with Package Manager Console [HowTo](https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/managing?tabs=vs#add-a-migration).

4. Run the application:

- Open with Visual Studio Community
  or
   ```bash
   dotnet run
   ```

5. Open your web browser and navigate to `http://localhost:5000`.

## Usage

- **Dashboard**: Gain insights into your financial health.
- **Transactions**: Add, edit, or delete income and expense entries.
- **Reports**: Generate detailed reports to analyze spending patterns.
- **More Features** is coming!


## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any inquiries, feel free to reach out to [devgodoy@icloud.com](mailto:devgodoy@icloud.com).

---

Thank you for using MyBudget - The Personal Finance Control System! We hope it helps you achieve your financial goals.
