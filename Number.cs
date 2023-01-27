namespace expression_evaluator;

class Number : Node
{
    public Number(double number) => _number = number;

    readonly double _number;

    public override double Eval()
    {
        return _number;
    }
}   