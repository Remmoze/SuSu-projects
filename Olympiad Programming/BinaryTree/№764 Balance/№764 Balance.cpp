#include <iostream>
#include <algorithm>

struct Node {
	int value;
	Node* left = nullptr;
	Node* right = nullptr;
	Node* parent = nullptr;
};

void insert(Node* root, Node* node) {
	if(root->left && root->value > node->value)
		return insert(root->left, node);
	if(root->right && root->value < node->value)
		return insert(root->right, node);
	if(root->value == node->value)
		return;
	if(root->value > node->value)
		root->left = node;
	else root->right = node;
	node->parent = root;
}

int size(Node* root) {
	if(!root) return 0;
	if(!root->left && !root->right)
		return 1;
	if(root->left && !root->right)
		return size(root->left) + 1;
	if(root->right && !root->left)
		return size(root->right) + 1;

	int lsize = size(root->left) + 1;
	int rsize = size(root->right) + 1;
	if(lsize > rsize)
		return lsize;
	return rsize;
}

int count(Node* node) {
	int sum = 1;
	if(node->left) sum += count(node->left);
	if(node->right) sum += count(node->right);
	return sum;
}

void traversal(Node* node) {//in-order
	if(node->left) traversal(node->left);
	printf("%i\n", node->value);
	if(node->right) traversal(node->right);
}

void leaves(Node* node) {
	if(node->left) leaves(node->left);
	if(!node->left && !node->right)
		printf("%i\n", node->value);
	if(node->right) leaves(node->right);
}

void intersections(Node* node) {
	if(node->left) intersections(node->left);
	if(node->left && node->right)
		printf("%i\n", node->value);
	if(node->right) intersections(node->right);
}

void branches(Node* node) {
	if(node->left) branches(node->left);
	if(node->left && !node->right || !node->left && node->right)
		printf("%i\n", node->value);
	if(node->right) branches(node->right);
}

//return -1 if unbalance was found. Height overwise.
int isBalanced(Node* node) {
	int c1 = 0, c2 = 0; // no children - no height
	if(node->left)
		c1 = isBalanced(node->left);
	if(node->right)
		c2 = isBalanced(node->right);

	// unbalance was found. Discard height, return -1
	if(c1 == -1 || c2 == -1) 
		return -1;

	if(!node->left && !node->right) // no children
		return 1;
	if(node->left && !node->right) //only left child
		return c1 > 1 ? -1 : c1 + 1;
	if(node->right && !node->left)
		return c2 > 1 ? -1 : c2 + 1;
	return std::abs(c1 - c2) > 1 ? -1 : std::max(c1, c2)+1;
}

int main() {
	Node* root = nullptr;

	int input;
	while(true) {
		std::cin >> input;
		if(input == 0)
			break;

		if(!root) {
			root = new Node;
			root->value = input;
		} else {
			Node* node = new Node;
			node->value = input;
			insert(root, node);
		}
	}
	if(isBalanced(root) == -1)
		printf("NO");
	else printf("YES");
	//std::cout << count(root) << std::endl;
}