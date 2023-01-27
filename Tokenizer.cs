using System.Text;

namespace expression_evaluator
{
    public class Tokenizer
    {
        public Tokenizer(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextToken();
        }

        private readonly TextReader _reader;
        private char _currentChar;

        public Token Token { get; private set; }

        public double Number { get; private set; }

        private void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }
        public void NextToken()
        {
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }
            switch (_currentChar)
            {
                case '\0':
                    Token = Token.EOF;
                    return;
                case '+':
                    NextChar();
                    Token = Token.Add;
                    return;
                case '-':
                    NextChar();
                    Token = Token.Subtract;
                    return;
                default:
                    break;
            }
            if (char.IsDigit(_currentChar) || _currentChar == '.')
            {
                StringBuilder sb = new();
                bool hasDecimalPoint = false;
                while (char.IsDigit(_currentChar) || (!hasDecimalPoint && _currentChar == '.'))
                {
                    sb.Append(_currentChar);
                    hasDecimalPoint = _currentChar == '.';
                    NextChar();
                }
                Number = double.Parse(sb.ToString());
                Token = Token.Number;
                return;
            }
            throw new InvalidDataException($"Unexpected character: {_currentChar}");
        }
    }
}