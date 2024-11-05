# HotelManager

## Description
HotelManager is a simple console application for checking hotel room availability using data from JSON files. The application reads room and booking data from `.json` files, allowing you to see which rooms are available based on the provided arrival and departure dates.

## Features
- Reads hotel and booking data from `.json` files
- Checks room availability based on date range
- Provides error messages if JSON files are missing or incorrectly formatted

## Requirements
1. Install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

   Alternatively, if you just want to run the app without building it, you can use the pre-built `.exe` file found in the main project directory.

## JSON Files
Ensure `hotels.json` and `bookings.json` are present in the project directory. These files contain the required hotel and booking data. They should download automatically with the repository, but if they are missing or incorrectly formatted, an error message will appear in the console with further instructions.

## Installation
To install and run this project, follow these steps:

1. Clone the repository:
```bash
git clone https://github.com/JUKKarol/HotelManager
```

2. Navigate to the project directory with the solution file:

```
cd <your-repo-directory>/HotelManager/HotelManager
```

3. Build the project:
```
 dotnet build
```

 ## Usage
To run the project after building it, use the following command in the same directory:

```
dotnet run
```

## Running Tests
To run the tests for this project:

1. Navigate to the test project directory:
```
cd <your-repo-directory>/HotelManager/HotelManager.Tests
```

2. Run the tests:
```
dotnet test
```