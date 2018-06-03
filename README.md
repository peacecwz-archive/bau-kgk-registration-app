# BAU KGK Registration App

This project is basic registration application for Bahcesehir University Carrier and Development Club. Simple registration app.

| Android | iOS |
| :-----: | :-: |
| [![Build status](https://build.appcenter.ms/v0.1/apps/be03f522-9f02-4221-89ec-ec47f95f41b2/branches/master/badge)](https://appcenter.ms) |  [![Build status](https://build.appcenter.ms/v0.1/apps/952802b6-13d8-4cbf-b66e-cd1224eca966/branches/master/badge)](https://appcenter.ms) |

## Getting Started

First of all, you need to clone the project to your local machine

```
git clone https://github.com/peacecwz/bau-kgk-registration-app.git
cd bau-kgk-registration-app
```

### Requirement

* Visual Studio 2017 or Visual Studio for Mac
* Xamarin Tools
* Android Emulator or Real Device (for Android App testing)
* iOS Simulator (for iOS App testing)
* Azure Account

### Building

A step by step series of building that project

1. Open the project with Visual Studio for Mac or Visual Studioe :hammer:
 
2. Create Azure Mobile App on Microsoft Azure Portal. [You can look at this documention for how to create an azure mobile app](https://docs.microsoft.com/en-us/azure/app-service-mobile/app-service-mobile-android-get-started)

2. Add Azure mobile app url to KGKRegister/App.xaml.cs file (line: 10)

```
    public static string BackendUrl = "https://myapp.azurewebsites.net/";
```
4. Run the project and Enjoy! :bomb:

## Demo

| Android | iOS |
| :-----: | :-: |
| ![Android](https://media.giphy.com/media/7IYt048CMPtsQcWlTq/giphy.gif) | ![iOS](https://media.giphy.com/media/Yj8bSavj38AxZ6Oerl/giphy.gif)  |


## Built With

* [Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/) 
* [Azure Mobile App](https://azure.microsoft.com/en-us/services/app-service/mobile/)

## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue

## License

This project is licensed under the MIT License
