using System;

public class WeightModel
{
    private int weightCurrent;
    private int weightMax;
    
    private WeightView weightView;
    
    public int Current
    {
        get => weightCurrent;
        set
        {
            weightCurrent = Math.Max(0, value);
            weightView.UpdateText(weightCurrent, weightMax);
            weightView.SetColorOverlimit(weightCurrent > weightMax);
        }
    }
    
    public int Max
    {
        get => weightMax;
        set
        {
            weightMax = Math.Max(0, value);
            weightView.UpdateText(weightCurrent, weightMax);
        }
    }

    public WeightModel(WeightView weightView)
    {
        this.weightView = weightView;
    }
}