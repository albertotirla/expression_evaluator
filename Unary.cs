
namespace expression_evaluator;
class Unary : Node
{
    public Unary(Node rhs, Func<double, double> op)
    {
        _rhs = rhs;
        _op = op;
    }

    readonly Node _rhs;
    readonly Func<double, double> _op;

    public override double Eval()
    {
        var rhsVal = _rhs.Eval();
        var result = _op(rhsVal);
        return result;
    }
}