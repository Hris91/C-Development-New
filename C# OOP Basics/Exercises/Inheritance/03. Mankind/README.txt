Your task is to model an application. It is very simple. The mandatory models of our application are 3:  Human, Worker and Student.
The parent class – Human should have first name and last name. Every student has a faculty number. Every worker has a week salary and work hours per day. It should be able to calculate the money he earns by hour. You can see the constraints below.
Input
On the first input line you will be given info about a single student - a name and faculty number. 
On the second input line you will be given info about a single worker - first name, last name, salary and working hours.
Output
You should first print the info about the student following a single blank line and the info about the worker in the given formats:
•	Print the student info in the following format: 
	First Name: {student's first name}
	Last Name: {student's last name}
	Faculty number: {student's faculty number}

•	Print the worker info in the following format:
	First Name: {worker's first name}
Last Name: {worker's second name}
Week Salary: {worker's salary}
Hours per day: {worker's working hours}
Salary per hour: {worker's salary per hour}
Print exactly two digits after every double value's decimal separator (e.g. 10.00). Consider the workweek from Monday to Friday. A faculty number should be consisted only of digits and letters.
