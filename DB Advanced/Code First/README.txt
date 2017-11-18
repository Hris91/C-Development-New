You went to your GP for your annual exam and you told him that you’ve started work as a Junior Database App Developer. It turned out he was looking for someone to make an app, which he could use to manage and store data about his patients.
Your task is to design a database using the Code First approach. The GP needs to keep information about his patients. Each patient has first name, last name, address, email, information whether he has medical insurance or not and should keep history about all his visitations, diagnoses and prescribed medicaments. Each visitation has date and comments. Each diagnose has name and comments for it. Each medicament has name. Validate all data before inserting it in the database.
Your Database should look something like this:
Remember! With Entity Framework Core you can have different column names from your classes’ property names!

Your classes should be:
	HospitalContext – your DbContext
	Patient:
	PatientId
	FirstName (up to 50 characters, unicode)
	LastName (up to 50 characters, unicode)
	Address (up to 250 characters, unicode)
	Email (up to 80 characters, not unicode)
	HasInsurance
	Visitation:
	VisitationId
	Date
	Comments (up to 250 characters, unicode)
	Patient
	Diagnose:
	DiagnoseId
	Name (up to 50 characters, unicode)
	Comments (up to 250 characters, unicode)
	Patient
	Medicament:
	MedicamentId
	Name (up to 50 characters, unicode)
	PatientMedicament – mapping class between Patients and Medicaments
