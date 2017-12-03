•	AddEmployee <firstName> <lastName> <salary> –  adds a new Employee to the database
•	SetBirthday <employeeId> <date: "dd-MM-yyyy"> – sets the birthday of the employee to the given date
•	SetAddress <employeeId> <address> –  sets the address of the employee to the given string
•	EmployeeInfo <employeeId> – prints on the console the information for an employee in the format "ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}"
•	EmployeePersonalInfo <employeeId> – prints all the information for an employee in the following format:
ID: 1 - Pesho Ivanov - $1000:00
Birthday: 15-04-1976
Address: Sofia, ul. Vitosha 15
•	Exit – closes the application
•	ManagerDto – first name, last name, list of EmployeeDtos that he/she is in charge of and their count
Add the following commands to your console application:
•	SetManager <employeeId> <managerId> – sets the second employee to be a manager of the first employee
•	ManagerInfo <employeeId> – prints on the console information about a manager in the following format:
Add a few employees to your database with their birthdays. 
Create a command "ListEmployeesOlderThan <age>" which lists all employees older than given age and their managers. 
Order them by salary descending. Add the necessary DTOs and commands to your application.