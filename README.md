# FeatureManagementExtensions

Some helpful extensions which are helpful for a cleaner FeatureToggles API. Just experimental at the moment.

## Installation

TODO

## Usage

```csharp
// 1. Add in Startup, right bellow registration of FeatureManagement
services.AddFeatureManagement(...); // Comes with Microsoft's FeatureManagement
services.AddFeatureChecker(); // <<----

// 2. Feature Flags class
public class MyFeatureToggles
{
    public bool AwesomeFeature { get; set; }
}

// 3. Use via Dependency Injection
public class MyService
{
    private readonly IFeatureChecker<MyFeatureToggles> featureChecker;

    public MyService(IFeatureChecker<MyFeatureToggles> featureChecker) 
    {
        this.featureChecker = featureChecker;
    }

    public async Task Foo()
    {
        // ...
        if (featureChecker.Check(x => x.AwesomeFeature))
            Console.WriteLine("Wohoo this is such an awesome feature!")
        else
            Console.WriteLine("Boring feature");
    }
}

// 4. Usage of other FeatureManager feature as before (like Controller Action Attributes or MVC Tag Helpers).
```


## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)