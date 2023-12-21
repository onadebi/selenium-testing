## Filteration of tests that would be run can be acheieved by making use of Traits

> Example:

```
[Fact]
[Trait("Category","CI")]
[Trait("Priority","1")]
public void CheckNotEmpty()
{
	Assert.False(String.IsNullOrWhiteSpace("NotEmpty"));
}
```

To filter test run by Traits, use the below command on the terminal:

```
dotnet test --filter "Category=CI"
```