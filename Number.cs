namespace expression_evaluator;

class Number : INode
{
    public Number(double number) => _number = number;

    readonly double _number;

    public double Eval()
    {
        return _number;
    }
}