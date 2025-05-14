# Agri-Energy Connect

**Agri-Energy Connect** is an innovative web platform aimed at bridging the gap between the agricultural sector and green energy technology providers. The initiative seeks to create a sustainable ecosystem by integrating agricultural data management and green energy solutions to support farmers in South Africa.

---

## Table of Contents

1. [Project Overview](#project-overview)
2. [Features](#features)
    - [For Farmers](#for-farmers)
    - [For Employees](#for-employees)
3. [Database Design](#database-design)
4. [User Roles and Authentication](#user-roles-and-authentication)
5. [Technologies Used](#technologies-used)
6. [Getting Started](#getting-started)
7. [Contributing](#contributing)
8. [License](#license)

---

## Project Overview

Agri-Energy Connect aims to empower farmers and agricultural workers by providing a platform that enables easy management of agricultural products, integrates green energy solutions, and promotes sustainable practices. By connecting farmers with green energy technology providers, we ensure a more efficient, eco-friendly future for agriculture.

---

## Features

### For Farmers

- **Product Addition**: Farmers can add their products to their profile with details such as:
  - Product Name
  - Category (e.g., Vegetables, Fruits, Livestock)
  - Production Date

- **Product Management**: View and manage their own product listings.

### For Employees

- **Farmer Profile Management**: Employees can create new farmer profiles by adding essential details like:
  - Farmer Name
  - Location
  - Farm Details

- **Product Search & Filter**: Employees can view all products from any farmer, and use filters such as:
  - Date Range
  - Product Type
  - Location (if applicable)

---

## Database Design

The relational database is designed to handle information about farmers and their products efficiently.

### Core Tables:
1. **Farmers**: Stores information about farmers, including their personal and farm details.
2. **Products**: Stores information about agricultural products, such as product name, category, production date, and the associated farmer.

Sample data has been populated to simulate real-world scenarios for demonstration and testing.

---

## User Roles and Authentication

### Roles

- **Farmer**: 
  - Can add products to their profile.
  - Can view their own product listings.
  
- **Employee**: 
  - Can add new farmer profiles.
  - Can view and filter a comprehensive list of products from any farmer based on criteria such as date range and product type.

### Authentication System

- **Login System**: 
  - Secure login for both farmers and employees.
  - Role-based access control to ensure users can only access their designated features.

---

## Technologies Used

- **Frontend**: HTML, CSS, JavaScript (React)
- **Backend**: Node.js, Express.js
- **Database**: MySQL (for relational database management)
- **Authentication**: JWT (JSON Web Tokens)
- **Deployment**: Docker (for containerization)

---

## Getting Started

To set up the project locally, follow these steps:

1. **Clone the repository**:

```bash
git clone https://github.com/YacheazyE/ProgTester---Agri-Energy-Connect.git
