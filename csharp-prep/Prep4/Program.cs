using System;
using System.Collections.Generic;

class Job
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}

class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; } = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Resume for {Name}:");
        foreach (var job in Jobs)
        {
            Console.WriteLine($"Job Title: {job.JobTitle}");
            Console.WriteLine($"Company: {job.Company}");
            Console.WriteLine($"Start Year: {job.StartYear}");
            Console.WriteLine($"End Year: {job.EndYear}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job
        {
            JobTitle = "Software Engineer",
            Company = "Microsoft",
            StartYear = 2019,
            EndYear = 2022
        };

        Job job2 = new Job
        {
            JobTitle = "Manager",
            Company = "Apple",
            StartYear = 2022,
            EndYear = 2023
        };

        Resume myResume = new Resume
        {
            Name = "Allison Rose"
        };

        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        myResume.Display();
    }
}
