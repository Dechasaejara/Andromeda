namespace API.Models.Dereja;
public class Topic
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Type { get; set; }
}

public class DetailNote
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public int Status { get; set; }
    public int Level { get; set; }
}

public class CheatSheet
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int TopicId { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; }
    public int Level { get; set; }
}

public class Exercise
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int TopicId { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; }
    public int Level { get; set; }
}

public class Solution
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Topic { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; }
    public int Level { get; set; }
}

public class AppConstant
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
}
