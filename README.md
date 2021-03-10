# simpleproject-poc

## Datenbank

### Ablauf DB erstellen

Um die Datenbank korrekt zu erstellen, müssen die SQL Scripts in korrekter Reihenfolge ausgeführt werden.

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