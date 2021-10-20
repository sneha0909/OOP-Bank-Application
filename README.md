# OOP-Bank-Application


Coding and reverse engineering

Recommended time to implement a task - 3 weeks.
Recommended time to pass - 4th laboratory class and 2nd midterm exam;
Deadline until points will be divided by 2 - all classes AFTER 2nd midterm exam.
Total deadline until project not available to pass - all classes AFTER 3rd midterm exam.
Points for project - 10.

Initial data for this project: ready to work project which was sended to you to gitlab. This project is about banks, accounts in banks and basic operations with bank accounts.

Main goals for this project: learn to understand someone else's code, learn to create Use Case diagrams from code, learn how to create class diagrams from code, learn how to modify someone else’s code.

At the beginning you will have a “ready to work” project. You need to understand how it works, understand the code. If you have problems with this project, or you don't understand how something works, at laboratory projects you need to ask questions, and the teacher will help you.

In this application, all OOP paradigms are used and you must understand how it works and specifically where which paradigm is applied.

What you need to do in this project:

Draw uml “class” diagram for all classes in initial project with relations between classes (ClassDiagBefore); Diagram need to save as picture/pdf file and add to repository and send to server.
Draw uml “use case” diagram for initial project (UseCaseBefore). To do that you must understand how program work and which actions user can do; In diagram must be two actors: “User” and “System” Diagram need to save as picture/pdf file and add to repository and send to server.
Add new types of exceptions for different operations. Exceptions must be inherited from base c# Exception type and your classes for exceptions must be protected from inheriting by other classes. (About exceptions read more in internet) (Exc) 
Add class “Person” with fields: Name, Age, InsuranceNumber, Phone, Email (Person). This class represent user, who work with banks (See code in initial project project). Objects of this class must be initialized when program starts.
Add link to Person in Account class; Initialize this relation in constructor.
Add to class “Account” field AccountNumber (string). AccountNumber must be as string with 8 characters length. It must contains ONLY numbers and letters only in uppercase. Not available to create number with special symbols or separators like (,.*&^%$#@! and others). AccountNumber must be initialized automatically in constructor when the object of any of derived from base Account class is created. (AccNum)
Add logic to Bank class to find account by AccountNumber. Need at least two methods. First will return whole Account object or throw exception if account not found, second must return string with account owner full name or throw exception if account not found. (AccFind)
Add method to Bank class to display all created in bank accounts (account number and name of owner must be displayed)
By default, in initial project, when program starts, only one instance of bank class created, you need to initialize at least 2 banks;
Add to bank class field named CreditPercentage. This field represent percentage, which need use when you work with credit accounts. (CredPerc)
Add to Account class link to Bank. This relation must be initialized when account is created (in constructor);
Add new class inherited from Account - CreditAccount. This class represent typical credit account. When user create this account, he need to enter sum of credit and loan repayment period in months. Monthly payment need to calculate using Bank percentage. You must come up with a formula for calculating percentage by yourself (you can use any formula, you free to choose) (Credit).
 You need to change main program logic. By default user get some choose to work with only one bank created when program starts. In modified program user first of all need to choose bank to work with. Then he can create different accounts, choose account to work with, add money, withdraw money, do transactions, close current account, view details about current account and other functions with selected account. Also you must have the right to choose other bank and work with it (NewMainLogic); Two understand more about this criteria read Typical workflow described below.
Add new logic to program to give user possibility to transfer money between accounts (in one bank). First step for user it’s choose on of his accounts from which he want to send money (need to choose account from current selected bank). Then user must choose other account from same bank as destination account (you can show list of accounts and choose by index or Id). Next step to user after finding account, entering money amount and complete transfer. Important to check  balance in account from which user try to send money (Transfer).
Draw classes diagram for modified program with all relations between classes(ClassDiagAfter); This diagram should be an advanced version of first class diagram for initial project. This diagram must contains all classes from initial project and all new classes described above, all new fields and relations described above. If some new fields or logic was added to initial classes, at this diagram it should be displayed. Diagram need to save as picture/pdf file and add to repository and send to server.
Draw uml use case diagram for modified project (UseCaseAfter). This diagram also must be advanced version of diagram for initial project. It must contains all new logic and functions for user described below. Diagram need to save as picture/pdf file and add to repository and send to server.

	
Program must validate user input all the time to prevent from errors.

	Typical workflow (users functionality step by step) for modified program:
Program starts;
User see list of all initialized banks with indexes, names, credit percentage;
User choose by index bank to work with; (Program remember selected bank and work with object of this bank)
Then user see all his accounts in current bank and he can choose any account to work with. Also he will see basic bank operations (open account, change bank etc…)
When user choose account he see account menu with options like add money, withdraw money, transfer money. By default, when user choose account, he must see money balance and some specific details for each account type (For example if user choose credit account he must see how much money he left to pay, how many months left to pay credit); Now about options for account:
If user choose option for withdraw money, he need to enter money amount which he want to get. If money on account not enough he must see error message. Else, he gets money.
If user choose add money option, he need to enter money amount to add. 
If user choose transfer money option, he must see list of his accounts in current bank and choose one of them to swap money between own accounts. User can view details of selected account like AccountNumber, money amount, credit percentage, monthly payment and other details;
User can go back to menu of current bank;

With blue color marked all information about NewLogic criteria functions which need to implement;

	Keys for user interface you must choose by yourself.
	In different menus (for bank, for account) use different background colors and different text colors, that helps to understand in which menu you right now.


IMPORTANT: SOME CRITERIAS IS DEPENDED ON OTHER CRITERIAS. IT MEANS, IF CRITERIA “B” Depended on “A” and you not implemented “A” you can’t get all points for “B”

This table shows which criteria depended on others.


Criteria
Points availability
Credit
All points not available without CredPerc criteria implemented.
Transfer
All points not available without Person, NewMainLogic criterias implemented.
NewMainLogic
All Points not available without person, credit, transfer, accNum, exc criterias implemented.
ClassDiagAfter
All points not available without Exc, Person, Credit, AccNum criterias implemented.
UseCaseAfter
All points not available without AccNum, CreditPerc, NewMainLogic, Transfer criterias implemented.




