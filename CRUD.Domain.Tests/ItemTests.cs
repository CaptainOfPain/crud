using System;
using CRUD.Domain.Items.DataStructures;
using CRUD.Domain.Items.Factories;
using CRUD.Domain.Items.Models;
using Moq;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using Xunit;

namespace CRUD.Domain.Tests;

public class ItemTests
{
    private IItemFactory _itemFactory;
    public ItemTests()
    {
        _itemFactory = new ItemFactory(new Mock<IDomainEventsManager>().Object);
    }
    
    [Fact]
    public void Should_Create_Item()
    {
        var item = _itemFactory.Create(new ItemDataStructure(AggregateId.Generate(), "Test", "test", DateTime.UtcNow.AddYears(1)));
        Assert.NotNull(item);
        Assert.Equal("Test", item.Name);
    }

    [Fact]
    public void Should_Update_Item()
    {
        var newName = "Test1234";
        var item = _itemFactory.Create(new ItemDataStructure(AggregateId.Generate(), "Test", "test", DateTime.UtcNow.AddYears(1)));
        item.Update(newName, item.Description, item.ExpirationDate);
        
        Assert.Equal(newName, item.Name);
    }

    [Fact]
    public void Should_Archive_Item()
    {
        var item = _itemFactory.Create(new ItemDataStructure(AggregateId.Generate(), "Test", "test", DateTime.UtcNow.AddYears(1)));
        item.MarkAsArchived();
        
        Assert.True(item.IsArchived);
    }
    
}