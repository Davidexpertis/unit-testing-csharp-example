# Elevator Project
## Beispiel von David Krammel für Git Tests und Unit Tests in C# mit Visual Studio

# Unit testing C# example

Example of **Unit Testing** using C# and **Visual Studio 2017**

### Description

Playing with unit tests in a real C# project, it's very interesting, just creating a new project with the purpose to test your main project. But be careful with all actions you want to test, they must be decoupled and available to be executed outside its class.

This solution has two projects:

1. **Elevator** which has the file *Elevator.cs* and the *MainTest.cs*

*Elevator.cs* has a class (Elevator) which controls the max weight allowed inside the elevator and if the user who is inside could go to vip section. And another class *Employee* which manages the weight and if the employee has permission to vip section.

![](Images/Elevator.cs.png)


*MainTest.cs* is just for execute the project inside a terminal window.


2. **ElevatorPoject.UnitTests** is where all unit tests are, inside the file *ElevatorTests.cs*

![](Images/ElevatorTests.cs.png)


### Installing

Open this project in your Visual Studio 2017 and make sure to open the "Tests explore Window" to execute the unit tests (Test > Windows > Tests Explore) 


## Running the tests

The test project has an archive called *ElevatorTests.cs* there you can see all the test functions which the Unit Test will execute automated. Check them out and feel free to add, modify and play with it.

![](Images/PassingAllTests.png)


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

---

## Web-App: ASP.NET Core Web API (.NET 8) + Angular + Playwright

Neben dem ursprünglichen Konsolenprojekt enthält das Repository jetzt zusätzlich eine Web-Anwendung, die dieselbe Elevator-Logik über eine REST-API und ein Angular-Frontend bereitstellt:

- `backend/ElevatorApi/` – ASP.NET Core Web API (.NET 8) mit der migrierten Elevator/Employee-Logik (`ElevatorController`: `status`, `in`, `out`, `vip-section`).
- `backend/ElevatorApi.Tests/` – xUnit-Unit-Tests (migriert aus `ElevatorProject.UnitTests`).
- `frontend/elevator-app/` – Angular-Frontend, das die Web API über `HttpClient` konsumiert, inkl. Playwright End-to-End-Tests.

### Voraussetzungen

- .NET 8 SDK
- Node.js (LTS) und npm
- Visual Studio für das Backend, VS Code (empfohlen) für Angular/Playwright

### Backend starten

```powershell
cd backend/ElevatorApi
dotnet run
```

Die API läuft standardmäßig unter `http://localhost:5173` (siehe `Properties/launchSettings.json`).

### Backend-Unit-Tests ausführen

```powershell
cd backend/ElevatorApi.Tests
dotnet test
```

Alternativ über den Visual Studio Test Explorer.

### Frontend starten

```powershell
cd frontend/elevator-app
npm install
npm start
```

Die App läuft unter `http://localhost:4200` und ruft die Backend-API unter `http://localhost:5173` auf (CORS ist im Backend für `http://localhost:4200` konfiguriert).

### Playwright End-to-End-Tests ausführen

```powershell
cd frontend/elevator-app
npx playwright install chromium   # einmalig
npm run e2e
```

Playwright startet den Angular Dev-Server automatisch (siehe `playwright.config.ts`, `webServer`). Für aussagekräftige Tests gegen echte Daten sollte zusätzlich das Backend laufen (`dotnet run` in `backend/ElevatorApi`).

### Empfehlung zur IDE

- **Visual Studio**: ideal für das C#-Backend (`backend/ElevatorApi`, `backend/ElevatorApi.Tests`) inkl. Test Explorer und Debugging.
- **Visual Studio Code**: empfohlen für das Angular-Frontend und Playwright-Tests (bessere npm/CLI-Integration, Playwright-Extension, TypeScript-Tooling).

Beide IDEs können parallel auf demselben Repository arbeiten.
