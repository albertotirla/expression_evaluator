namespace expression_evaluator;
class BinaryOperation : Node
{
    public BinaryOperation(Node lhs, Node rhs, Func<double, double, double> op)
    {
        _lhs = lhs;
        _rhs = rhs;
        _op = op;
    }

    readonly Node _lhs;
    readonly Node _rhs;
    readonly Func<double, double, double> _op;

    public override double Eval()
    {
        var lhsVal = _lhs.Eval();
        var rhsVal = _rhs.Eval();
        var result = _op(lhsVal, rhsVal);
        return result;
    }
}