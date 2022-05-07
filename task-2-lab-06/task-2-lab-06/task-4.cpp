#include <iostream>

using namespace std;

class TreeNode 
{
public:
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

class Solution
{
public:
    bool isCompleteTree(TreeNode* root)
    {
        int nodeCount = countNodes(root);
        return isComplete(root, 0, nodeCount);
    }

private:
    int countNodes(TreeNode* root)
    {
        if (!root)
        {
            return 0;
        }
        return 1 + countNodes(root->left) + countNodes(root->right);
    }

    bool isComplete(TreeNode* root, int index, int nodeCount)
    {
        if (!root)
        {
            return true;
        }

        if (index >= nodeCount)
        {
            return false;
        }

        return isComplete(root->left, 2 * index + 1, nodeCount) &&
            isComplete(root->right, 2 * index + 2, nodeCount);
    }
};

int main() {
    TreeNode* root = new TreeNode(1);
    root->right = new TreeNode(3);
    /*root->left = new TreeNode(2);
    root->left->left = new TreeNode(4);
    root->left->right = new TreeNode(5);
    root->right->left = new TreeNode(6);*/

    Solution solution;
    if (solution.isCompleteTree(root)) {
        cout << "The binary tree is a complete binary tree.\n";
    }
    else {
        cout << "The binary tree is not a complete binary tree.\n";
    }
    cout << endl;
    return 0;
}