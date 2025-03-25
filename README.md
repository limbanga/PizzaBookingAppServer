# PizzaBookingApp

## Project Introduction

PizzaBookingApp is a web application developed with the primary goal of providing an easy and efficient way to order pizza online. This application allows users to browse various pizza options, customize their orders, and seamlessly place bookings.

## Technologies Used

- **C#**: Backend logic and API development.
- **HTML**: Frontend structure and design.
- **CSS**: Styling and layout.
- **JavaScript**: Interactive elements and functionalities.
- **SQL**: Database management.
- **ASP.NET Web API**: Web framework for building APIs.
- **Blazor Page**: Framework for building interactive client-side web pages.

## Key Features

### General Features

- **User Authentication**:
  - User login to access the system.
  - User registration via the website.
  - Email verification for authentication.
  - Password reset functionality.
  - Password change functionality.
  - Role-based access control for customers and admins.

- **Shopping Features**:
  - View the list of available products.
  - Add products to the shopping cart.
  - Search for products by name or category.
  - Order payment functionality.

### Admin Features

- **Category Management**:
  - Add, edit, and delete category information.
  - Display the list of categories.
  - Search by category name.

- **Product Management**:
  - Add, edit, and delete product information.
  - Display the list of products.
  - Search by product name.

- **Customer Management**:
  - Display the list of customers.
  - Search for customers by name, phone number, or address.

- **Order Management**:
  - Customers can place and pay for orders.
  - Display the list of created orders along with order status.
  - View order details.
  - Modify order status.

- **Reports and Statistics**:
  - Display revenue reports by month/year.
  - View graphical revenue representation by month/year.

### Advanced Features

- The website follows a web API architecture. The client-side Single Page Application ensures a smooth user experience.
- Input validation implemented.
- Uses debounce techniques to enhance performance.
- Responsive design compatible with multiple screen sizes.
- Utilizes client-side storage for necessary user information.
- Handles route parameters for SEO optimization.
- Includes a theme switcher (light/dark mode).

## How to Run the Project

*A demo guide is provided along with the project 😄*

To obtain a local copy and run the project, follow these simple steps:

### Prerequisites

- .NET SDK
- Visual Studio or any other C# IDE
- SQL Server

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/limbanga/PizzaBookingApp.git
   ```
2. Navigate to the project directory:
   ```sh
   cd PizzaBookingApp
   ```
3. Open the project in your preferred IDE (e.g., Visual Studio).
4. Restore NuGet packages:
   ```sh
   dotnet restore
   ```
5. Update the database connection string in `appsettings.json`.
6. Run the server application:
   1. Navigate to the server directory:
   ```sh
   cd PizzaBookingAppServer
   ```
   2. Start the application:
   ```sh
   dotnet run
   ```
7. Run the client application:
   1. Navigate to the client directory:
   ```sh
   cd PizzaBookingAppClient
   ```
   2. Start the application:
   ```sh
   dotnet run
   ```

## Demo

You can check out the application demo here: [PizzaBookingApp Demo](https://drive.google.com/drive/folders/1XgMgY8oiDnMTyJifk4VBCyoVtoyGpuJ8?usp=sharing)

