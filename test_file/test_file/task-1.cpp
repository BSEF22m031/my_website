#include <iostream>
#include <string>
using namespace std;

class VariableNode
{
public:
    string variableName;
    int value;
    VariableNode* next;

    VariableNode(string name, int val) : variableName(name), value(val), next(nullptr) {}
};

// StackNode class 
class StackNode
{
public:
    char data;
    StackNode* next;

    StackNode(char value) : data(value), next(nullptr) {}
};

// Stack class for the stack functions
class Stack
{
public:
    StackNode* top;

    Stack() : top(nullptr) {}

    void push(char c)
    {
        StackNode* newNode = new StackNode(c);
        newNode->next = top;
        top = newNode;
    }

    char pop()
    {
        if (top == nullptr)
        {
            return '\0'; //empty
        }
        char value = top->data;
        StackNode* temp = top;
        top = top->next;
        delete temp;
        return value;
    }

    char peek()
    {
        if (top == nullptr)
        {
            return '\0';
        }
        return top->data;
    }

    bool isEmpty()
    {
        return top == nullptr;
    }
};

int precedence(char op)
{
    if (op == '+' || op == '-')
    {
        return 1;
    }
    if (op == '*' || op == '/')
    {
        return 2;
    }
    return 0;
}

string infixToPostfix(string expression)
{
    Stack stack;
    string postfix = "";
    for (int i = 0; i < expression.length(); i++)
    {
        char c = expression[i];

        // If the character is other than operator
        if (isalnum(c))
        {
            postfix = postfix + c;
        }
        // If the character is '('
        else if (c == '(')
        {
            stack.push(c);
        }
        // If the character is ')'
        else if (c == ')')
        {
            while (!stack.isEmpty() && stack.peek() != '(')
            {
                postfix = postfix + stack.pop();
            }
            stack.pop();
        }
        // If it is a operator
        else
        {
            while (!stack.isEmpty() && precedence(stack.peek()) >= precedence(c))
            {
                postfix = postfix + stack.pop();
            }
            stack.push(c);
        }
    }

    // remove all other things from stack
    while (!stack.isEmpty())
    {
        postfix = postfix + stack.pop();
    }

    return postfix;
}

VariableNode* extractVariables(string expression)
{
    VariableNode* head = nullptr;
    VariableNode* last = nullptr;

    for (int i = 0; i < expression.length(); i++)
    {
        char c = expression[i];
        if (isalpha(c))
        {
            string varName = "";
            while (i < expression.length() && isalnum(expression[i]))
            {
                varName += expression[i++];
            }
            i--;

            // value for the variable
            int value;
            cout << "Enter value for " << varName << ": ";
            cin >> value;

            VariableNode* newNode = new VariableNode(varName, value);
            if (!head)
            {
                head = newNode;
            }
            else
            {
                last->next = newNode;
            }
            last = newNode;
        }
    }

    return head;
}

int getVariableValue(string varName, VariableNode* head)
{
    VariableNode* current = head;
    while (current != nullptr)
    {
        if (current->variableName == varName)
        {
            return current->value;
        }
        current = current->next;
    }
    return 0; // return 0 no variable found
}

int evaluatePostfix(string postfixExpression, VariableNode* variableList)
{
    Stack stack;

    for (int i = 0; i < postfixExpression.length(); i++)
    {
        char c = postfixExpression[i];

        if (isalnum(c))
        {
            if (isalpha(c))
            {
                string varName = "";
                while (i < postfixExpression.length() && isalnum(postfixExpression[i])) {
                    varName += postfixExpression[i++];
                }
                i--; // step back after the loop
                int value = getVariableValue(varName, variableList);
                stack.push(value + '0'); // store as character
            }
            else
            {
                stack.push(c);
            }
        }
        // If the character is an operator, pop two elements from the stack 
        else
        {
            int val2 = stack.pop() - '0';
            int val1 = stack.pop() - '0';
            switch (c)
            {
            case '+': stack.push(val1 + val2 + '0'); break;
            case '-': stack.push(val1 - val2 + '0'); break;
            case '*': stack.push(val1 * val2 + '0'); break;
            case '/': stack.push(val1 / val2 + '0'); break;
            }
        }
    }

    return stack.pop() - '0'; // The result
}

int main()
{
    string infixExpression;
    cout << "Enter infix expression: ";
    cin >> infixExpression;

    string postfixExpression = infixToPostfix(infixExpression);
    cout << postfixExpression<<endl;
    VariableNode* variables = extractVariables(infixExpression);
    int result = evaluatePostfix(postfixExpression, variables);

    cout << "Evaluation Result: " << result << endl;

    return 0;
}
