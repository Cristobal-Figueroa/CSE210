using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string goalType = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();
        
        Goal newGoal;
        
        switch (goalType)
        {
            case "1": // Simple Goal
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2": // Eternal Goal
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3": // Checklist Goal
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
        
        _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create some goals first.");
            return;
        }
        
        ListGoalNames();
        
        Console.Write("\nWhich goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            
            bool wasAlreadyComplete = goal.IsComplete();
            
            goal.RecordEvent();
            
            int pointsEarned = goal.GetPoints();
            
            if (goal is ChecklistGoal checklistGoal && !wasAlreadyComplete && goal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                pointsEarned += bonus;
                Console.WriteLine($"Congratulations! You have earned a bonus of {bonus} points!");
            }
            
            _score += pointsEarned;
            
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        try
        {
            _goals.Clear();
            
            string fileContent = File.ReadAllText(filename);
            Console.WriteLine($"File content:\n{fileContent}");
            
            string[] lines = File.ReadAllLines(filename);
            Console.WriteLine($"Number of lines: {lines.Length}");
            
            if (lines.Length > 0)
            {
                if (int.TryParse(lines[0], out int score))
                {
                    _score = score;
                    Console.WriteLine($"Score loaded: {_score}");
                }
                else
                {
                    Console.WriteLine($"Could not convert score: '{lines[0]}'. Using 0.");
                    _score = 0;
                }
                
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    Console.WriteLine($"Processing line {i}: '{line}'");
                    
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("  Empty line, skipping.");
                        continue;
                    }
                    
                    string[] parts = line.Split(":");
                    if (parts.Length < 2)
                    {
                        Console.WriteLine($"  Error: incorrect format, does not contain ':'");
                        continue;
                    }
                    
                    string goalType = parts[0];
                    string goalData = parts[1];
                    string[] goalParts = goalData.Split(",");
                    
                    Console.WriteLine($"  Type: {goalType}, Parts: {goalParts.Length}");
                    foreach (var part in goalParts)
                    {
                        Console.WriteLine($"    - {part}");
                    }
                    
                    Goal goal = null;
                    
                    try
                    {
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                if (goalParts.Length >= 3)
                                {
                                    string name = goalParts[0];
                                    string description = goalParts[1];
                                    string points = goalParts.Length > 2 ? goalParts[2] : "0";
                                    bool isComplete = goalParts.Length > 3 ? bool.Parse(goalParts[3]) : false;
                                    
                                    goal = new SimpleGoal(name, description, points, isComplete);
                                    Console.WriteLine($"  Created SimpleGoal: {name}");
                                }
                                break;
                            case "EternalGoal":
                                if (goalParts.Length >= 2)
                                {
                                    string name = goalParts[0];
                                    string description = goalParts[1];
                                    string points = goalParts.Length > 2 ? goalParts[2] : "0";
                                    
                                    goal = new EternalGoal(name, description, points);
                                    Console.WriteLine($"  Created EternalGoal: {name}");
                                }
                                break;
                            case "ChecklistGoal":
                                if (goalParts.Length >= 3)
                                {
                                    string name = goalParts[0];
                                    string description = goalParts[1];
                                    string points = goalParts.Length > 2 ? goalParts[2] : "0";
                                    int target = goalParts.Length > 3 ? int.Parse(goalParts[3]) : 5;
                                    int bonus = goalParts.Length > 4 ? int.Parse(goalParts[4]) : 100;
                                    int amountCompleted = goalParts.Length > 5 ? int.Parse(goalParts[5]) : 0;
                                    
                                    goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                                    Console.WriteLine($"  Created ChecklistGoal: {name}");
                                }
                                break;

                            default:
                                Console.WriteLine($"  Error: unknown goal type: {goalType}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  Error processing goal: {ex.Message}");
                    }
                    
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
            
            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine($"Loaded {_goals.Count} goals.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
