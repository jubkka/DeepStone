public class ExperienceModel
{
    
    private int currentExp;
    private int countExpToNextLevel;

    public int CurrentExp
    {
        get => currentExp;
        set
        {
            currentExp = value;
            view.UpdateExperience(value);
        }
    }

    public int CountExpToNextLevel
    {
        get => countExpToNextLevel;
        set
        {
            countExpToNextLevel = value;
            view.UpdateCountExpToNextLevel(value);
        }
    }

    private ExperienceView view;

    public ExperienceModel(ExperienceView view)
    {
        this.view = view;
    }
}