using System;

public class WeightModel
{
    private readonly WeightView weightCurrentView;
    private readonly WeightView weightMaxView;
    
    private int weightCurrent;
    private int weightMax;

    public int Current
    {
        get => weightCurrent;
        set
        {
            weightCurrent = value;
            weightCurrentView.UpdateText(weightCurrent);
        }
    }

    public int Max
    {
        get => weightMax;
        set
        {
            weightMax = Math.Max(1, value);
            weightMaxView.UpdateText(weightMax);
        }
    }
    
    public WeightModel(int weightMax, WeightView weightCurrentView, WeightView weightMaxView)
    {
        weightCurrent = 0;
        this.weightMax = weightMax;
        
        this.weightCurrentView = weightCurrentView;
        this.weightMaxView = weightMaxView;
    }
}