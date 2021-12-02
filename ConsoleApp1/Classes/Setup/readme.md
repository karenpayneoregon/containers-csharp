# About 

ProtoTypeConfiguration class creates the basic structure for appsettings.json as presented in figure 1 then adjusted with labels as shown in figure 2.

# Figure 1

```json
[
  {
    "Environment": "Development",
    "ReloadApplicationOnEveryRequest": true,
    "Trace": false,
    "Reload": "reload",
    "Password": true,
    "DiConfiguration": {
      "Dsn": "OCS",
      "Globals": "globals",
      "Globals2": "globals2",
      "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
      "ExitLink": "/ocs4/",
      "OcsLink": null,
      "MfLink": "",
      "MfUser": null,
      "MfPass": "",
      "UseGeoLocation": true,
      "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
      "BaseServerAddress": "ocs4",
      "UirTakeTest": false,
      "QryCacheShort": "00:00:10",
      "QryCacheLong": "00:00:05"
    }
  },
  {
    "Environment": "Test",
    "ReloadApplicationOnEveryRequest": false,
    "Trace": false,
    "Reload": "reload",
    "Password": true,
    "DiConfiguration": {
      "Dsn": "OCS",
      "Globals": "globals",
      "Globals2": "globals2",
      "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
      "ExitLink": "/ocs4/",
      "OcsLink": null,
      "MfLink": "",
      "MfUser": null,
      "MfPass": "",
      "UseGeoLocation": true,
      "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
      "BaseServerAddress": "ocs4",
      "UirTakeTest": false,
      "QryCacheShort": "00:10:00",
      "QryCacheLong": "00:01:00"
    }
  },
  {
    "Environment": "Production",
    "ReloadApplicationOnEveryRequest": false,
    "Trace": false,
    "Reload": "reload",
    "Password": true,
    "DiConfiguration": {
      "Dsn": "OCS",
      "Globals": "globals",
      "Globals2": "globals2",
      "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
      "ExitLink": "/ocs4/",
      "OcsLink": null,
      "MfLink": "",
      "MfUser": null,
      "MfPass": "",
      "UseGeoLocation": true,
      "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
      "BaseServerAddress": "ocs4",
      "UirTakeTest": false,
      "QryCacheShort": "06:00:00",
      "QryCacheLong": "00:30:00"
    }
  }
]
```
# Figure 2

```json
{

  "Environment": {
    "Name": "Production"
  },
  "GeneralSettings": [
    {
      "Environment": "Development",
      "ReloadApplicationOnEveryRequest": true,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "DiConfiguration": {
        "Dsn": "OCS",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
        "BaseServerAddress": "ocs4",
        "UirTakeTest": false,
        "QryCacheShort": "00:00:10",
        "QryCacheLong": "00:00:05"
      }
    },
    {
      "Environment": "Test",
      "ReloadApplicationOnEveryRequest": false,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "DiConfiguration": {
        "Dsn": "OCS",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
        "BaseServerAddress": "ocs4",
        "UirTakeTest": false,
        "QryCacheShort": "00:10:00",
        "QryCacheLong": "00:01:00"
      }
    },
    {
      "Environment": "Production",
      "ReloadApplicationOnEveryRequest": false,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "DiConfiguration": {
        "Dsn": "PPP",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/ocs4/pinchange/index.cfm/main/begin/",
        "BaseServerAddress": "ocs4",
        "UirTakeTest": false,
        "QryCacheShort": "06:00:00",
        "QryCacheLong": "00:30:00"
      }
    }
  ]
}
```


