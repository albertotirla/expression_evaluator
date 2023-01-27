namespace expression_evaluator;
public class Parser
{
    public Parser(Tokenizer tokenizer)
    {
        _tokenizer = tokenizer;
    }

    Tokenizer _tokenizer;

    public Node ParseExpression()
    {
        var expr = ParseKnownOperations();

        // Check everything was consumed
        if (_tokenizer.Token != Token.EOF)
        {
            throw new SyntaxException("Unexpected characters at end of expression");
        }
        return expr;
    }
    Node ParseKnownOperations()
    {
        var lhs = ParseFactor();
        while (true)
        {
            Func<double, double, double> op = null;
            if (_tokenizer.Token == Token.Add)
            {
                op = (a, b) => a + b;
            }
            else if (_tokenizer.Token == Token.Subtract)
            {
                op = (a, b) => a - b;
            }
            if (op == null)
            {
                return lhs;
            }
            _tokenizer.NextToken();
            var rhs = ParseFactor();
            lhs = new BinaryOperation(lhs, rhs, op);
        }
    }
    Node ParseFactor()
    {
        if (_tokenizer.Token == Token.Number)
        {
            var node = new Number(_tokenizer.Number);
            _tokenizer.NextToken();
            return node;
        }
        throw new SyntaxException($"Unexpected token: {_tokenizer.Token}");
    }
}