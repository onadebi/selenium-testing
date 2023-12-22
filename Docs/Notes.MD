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
<strong style='color:ornage;'>Note that the filter name (in this case 'Category') is case sensitive, while the value is not.</strong>
```
dotnet test --filter "Category=CI"
```