
---

# MoviesApp - .NET Web API with Angular Client

This project consists of a .NET Core Web API for managing movies and an Angular client for interacting with the API. The Web API includes CRUD endpoints for movies, filtering, pagination, sorting, and validation. The Angular client provides a user-friendly interface for interacting with the API.

## Getting Started

Follow these instructions to set up and run the project locally.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 8.0)
- [Node.js](https://nodejs.org/) (with npm)
- Angular CLI: Install globally via npm `npm install -g @angular/cli`

### Running the API

1. Clone this repository:

    ```bash
    git clone <repository-url>
    cd MovieApi
    ```

2. Set up the API:

    - **Development Configuration**: Run the following commands:

        ```bash
        cd MovieApi
        dotnet build
        dotnet run --project MovieApi
        ```

3. The API should now be running locally. Open a web browser and navigate to `https://localhost:7405/api/movies/all` to verify.

### Running the Angular Client

1. Navigate to the Angular client directory:

    ```bash
    cd MovieClient
    ```

2. Install dependencies:

    ```bash
    npm install
    ```

3. Run the Angular application:

    ```bash
    ng serve
    ```

4. Open a web browser and navigate to `http://localhost:4200` to view the Angular client.

## Usage

- Use the Angular client interface to interact with the API.
- Create, update, delete, and view movies.
- Use filtering, pagination, and sorting functionalities to manage movie data efficiently.

## Technologies Used

- .NET Core Web API
- Angular
- Entity Framework Core (for database interactions)
- Bootstrap (for styling)

