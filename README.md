Starter App – Library of Things
About this project

This is a .NET MAUI app I built for my coursework. It’s basically a Library of Things system where users can log in, browse items, and manage rentals.

The app was developed in stages (Tier 1 and Tier 2), starting with basic login and navigation, then building up to a more complete rental system with services and better structure.

What it does:
Tier 1
Lets users register and log in
Basic navigation between pages
Simple dashboard once logged in
Stores user data in a database
Tier 2
Rental system (borrow and return items)
Location service added
Better structure using MVVM
Services added to keep logic separate
Improved app flow and navigation
Tech used
.NET MAUI
C#
MVVM pattern
XAML for UI
SQLite / local database
Dependency Injection
Project structure
StarterApp/
├── Models
├── Views
├── ViewModels
├── Services
├── Database
├── AppShell.xaml
└── MauiProgram.cs

How to run it:
Clone the repo
Open it in Visual Studio
Restore NuGet packages
Build the project
Run it on Windows or Android emulator

What I learned:
How MVVM actually works in a real project
How to split logic into services instead of putting everything in one file
How navigation works in MAUI
How to connect a simple database to an app
How to structure a bigger project instead of everything being messy
Future improvements

If I had more time, I’d:

Improve the UI design
Add better error handling
Add user roles (admin/user)
Make the rental system more advanced
Possibly connect it to a cloud database

Author:
Bhupinder Singh Vig
