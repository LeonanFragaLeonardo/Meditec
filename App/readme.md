This mobile application was developed using Xamarin (C #) and Visual Studio CE 2017.

This application was developed using MVVM concepts.
There are four main packages, which are: Models, ViewModels, Views and Services.

The Models package has classes directly related to the database tables.
The Views package has graphical user interface classes, which contain XAML files, which in turn define application layouts. There are rare exceptions where there is important code in the code behind (.cs files inside within the View classes)
The ViewModels package has classes that allow Views to communicate with the Models classes, making the code cleaner.