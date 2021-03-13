# simpleproject-poc

# Tool

simpleproject-poc ist ein Prototyp einer Applikation zu Verwaltung von Projekten. Voraussetzung: Windows OS, .NET Framework 4.7.2 & MS SQL Server Express

## Datenbank

Die Datenbank ist direkt im Tool integriert (MDF / LDF) und muss grundsätzlich nicht erstellt werden. Besteht jedoch der Bedarf die DB manuell mit den Scripts anzulegen, können diese im Ordner \sql-scripts gefunden werden.

### Ablauf DB erstellen

Um die Datenbank korrekt mit den SQL Scripts zu erstellen, müssen diese in korrekter Reihenfolge ausgeführt werden.

**Step 1:**
* CREATE_DB_simpleproject-poc.sql

Wichtig: Im Create DB Script ist der Pfad zum Datenbank .mdf und .ldf File angegeben. Dies kann je nach SQL Server Installation varieren.

**Step 2:**
* CREATE_TABLE_Project_method.sql

**Step 3:**
* CREATE_TABLE_Project.sql
* CREATE_TABLE_Phase.sql

**Step 4:**
* CREATE_TABLE_Project_phase.sql

**Step 5:**
* CREATE_TABLE_Milestone.sql
* CREATE_TABLE_Department.sql
* CREATE_TABLE_Cost_type.sql
* CREATE_TABLE_Function.sql

**Step 6:**
* CREATE_TABLE_Employee.sql

**Step 7:**
* CREATE_TABLE_Activity.sql

**Step 8:**
* CREATE_TABLE_External_cost.sql
* CREATE_TABLE_Personal_resource.sql