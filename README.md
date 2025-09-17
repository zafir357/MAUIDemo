Overview

LeagueOfLegends – MAUI Demo is a simple .NET MAUI app that lets you browse League-style champions, view details, and edit a champion’s name, bio, and skills.
The project is structured with MVVM (Models, ViewModels, Views) to keep UI and logic cleanly separated.

Features

Champion list & detail pages

Pagination

Image display on MAUI

Edit page with:

Name (editable)

Bio (editable)

Class (displayed, read-only)

Skills list (edit descriptions) + “Add skill” box

“Save” button applies edits to the underlying model (and can navigate back)

Tech stack

.NET MAUI (.NET 7/8)

MVVM with ICommand and property change notifications

C# models: Champion, Skill, ChampionClass enum

Project layout
Sources/
  ClientMAUI/                 # MAUI app (UI)
    Views/Pages/              # e.g., ChampionListPage, ChampionDetailPage, ChampionEditPage
    VMApp/                    # Page ViewModels (e.g., ChampionEditPageVM)
  VM/                         # Core ViewModels (e.g., ChampionVM, SkillVM)
  Model/                      # Domain models (Champion, Skill, etc.)
  Shared/, StubLib/, Tests/   # Helpers, stubs, unit tests

How it works (MVVM)

Model: Champion holds Name, Bio, Class, Skills.

ViewModel: ChampionVM exposes bindable properties; ChampionEditPageVM provides AddSkillCommand and SaveCommand.

View (XAML): binds to VM (e.g., Text="{Binding ChampionVM.Name}"), commands wired to buttons.

Getting started:

Install Visual Studio 2022 with the .NET MAUI workload (Android/iOS tools as needed).

Open LeagueOfLegends.sln.

Set ClientMAUI as startup project.

Deploy to Android emulator or Windows (if using WinUI).

If you see build output directories in Git, add a .gitignore (ignore .vs/, bin/, obj/, **/Platforms/**/bin, **/Platforms/**/obj, and *.zip).

Usage:

Launch the app → choose a champion → Edit.

Change Name/Bio, add a skill via the input and +.

Tap Save to apply changes (the app can show a “Saved” alert and return).

Roadmap / Ideas:

Add feature for the listing

Image pickers & icons

Persist data to storage or web API

Validation & undo

Unit tests for ViewModels
