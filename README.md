# DLM-NET

A .NET library for communicating with the Digital License Manager APIs.

## Initialization

You need to create instance of the DLM_NET.Service class in order to be able to interact with the APIs.

```csharp

using DLM_NET;
using DLM_NET.Http.Responses;
using DLM_NET.Models;

Service service = new Service("http://dlm.test", "Your_Consumer_Key", "Your_Consumer_Secret");
Result<License> result = service.Licenses().Find("AAAA-AAAA-AAAA-AAAA");

```

## Retrieving License

The `Licenses.Find()` method returns object of type `DLM_NET.Http.Responses.Result`

```csharp

Result<License> result = service.Licenses().Find("AAAA-AAAA-AAAA-AAAA");

if(!result.isError()) {
  Console.WriteLine("License Key: " + result.data.license_key);
  Console.WriteLine("Expires at: " + result.data.expires_at);
  Console.WriteLine("Activations count: " + result.data.activations.Count);
}

```

## Activating License

The `Licenses.Activate()` method returns object of type `DLM_NET.Http.Responses.Result`

The `Result.data` property is of type `DLM_NET.Models.Activation`. It represents the "Activation" record created in the central system.

```csharp

Result<Activation> result = service.Licenses().Activate("AAAA-AAAA-AAAA-AAAA");

if(!result.isError()) {
  Console.WriteLine("Activation Token: " + result.data.token);
  SaveTokenInDatabase(result.data.token) // You need to store this token somewhere.
}

```

## Validating License Activation

The `Licenses.Validate()` method returns object of type `DLM_NET.Http.Responses.Result`

The `Result.data` property is of type `DLM_NET.Models.Activation`. It represents the "Activation" record created in the central system.

**Note:** Use this method to check if the activation exist in the central system and if it is valid.

**Note:** You should also check if the license expired as explained below.

```csharp

Result<Activation> result = service.Licenses().Validate("AAAA-AAAA-AAAA-AAAA");

if(!result.isError()) {
  Console.WriteLine("Activation Token: " + result.data.token);
  SaveTokenInDatabase(result.data.token) // You need to store this token somewhere.
  
  if(result.data.license.IsExpired()) {
    Console.WriteLine("License is not expired"); // Do something if the license expired, perhaps warn user?
  }
  
  if(result.data.IsActive() {
    Console.WriteLine("License Activation is OK."); // Check if the activation record is OK and not terminated/deactivated.
  }
}

```

## Deactivating License

The `Licenses.Deactivate()` method returns object of type `DLM_NET.Http.Responses.Result`

The `Result.data` property is of type `DLM_NET.Models.Activation`. It represents the "Activation" record created in the central system.

**Note**: Deactivating license will set the Activation.deactivated_at property with the date when the deactivation occoured, otherwise it is always NULL.

```csharp

Result<Activation> result = service.Licenses().Deactivate("732f6e77a6a2373ed24315c6e2a606eb8d7c46b3"); // Note: This is token, not license key.

if(!result.isError()) {
  Console.WriteLine("Activation Token: " + result.data.token);
  DeleteTokenFromDatabase(result.data.token) // You can delete the stored token.
}

```

## Handling Errors

You can retrieve the error message by using the `DLM_NET.Http.Responses.Result` class as follows.

```csharp

Result<License> result = service.Licenses().Find("AAAA-AAAA-AAAA-AAAA");

if(!result.isError()) {
  Console.WriteLine("License Key: " + result.data.license_key);
  Console.WriteLine("Is Expired: " + result.data.IsExpired() ? "Yes" : "No");
} else {
  Console.WriteLine("Error: " + result.data.message); // Print the message if it is error.
}

```

## Contributions

Contributions and pull requests are welcome, feel free to open a pull request or suggest a feature.

## License

```
Copyright (C) 2022 IDEOLOGIX Media (https://darkog.com)

This file is part of Digital License Manager

Digital License Manager is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

Digital License Manager is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Digital License Manager. If not, see <https://www.gnu.org/licenses/>.
```


