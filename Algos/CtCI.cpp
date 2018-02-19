#include <string.h>
#include <stdio.h>
#include <map>
#include <iostream>
#include <cstdlib>
#include <iomanip>

using namespace std;

void reverse(char *str1)
{
	if (str1){
		char *end = str1;
		while (*end)
		{
			end++;
		}
		end--;
		while (str1 < end)
		{
			char t = *str1;
			*str1++ = *end;
			*end-- = t;
		}
	}
	printf("%s\n", str1);
}

void test_12()
{
	char str [] = "ABC";
	printf("%s\n", str);
	for (int i = 0, j = strlen(str) - 1; i < j; i++, j--)
	{
		char c = str[i];
		str[i] = str[j];
		str[j] = c;
	}
	printf("%s\n", str);

	char *str1 = "ABC\0";
	reverse(str1);
}

struct Node {
	int data;
	Node* ptr1;
	Node* ptr2;
	Node(int d) : data(d), ptr1(NULL), ptr2(NULL) {};
	friend std::ostream & operator << (std::ostream & _stream, Node const & mc) {
		_stream << mc.data;
		if (mc.ptr1 != NULL)
			_stream << ' ' << mc.ptr1->data;
		if (mc.ptr2 != NULL)
			_stream << ' ' << mc.ptr2->data;
		_stream << std::endl;
		return _stream;
	}
};

typedef map<Node*, Node*> NodeMap;

Node* copy_recursive(Node* cur, NodeMap& nodeMap)
{
	if (cur == NULL)
	{
		return NULL;
	}

	NodeMap::iterator i = nodeMap.find(cur);
	if (i != nodeMap.end())
	{
		return i->second;
	}

	Node* node = new Node(cur->data);
	nodeMap[cur] = node;
	node->ptr1 = copy_recursive(cur->ptr1, nodeMap);
	node->ptr2 = copy_recursive(cur->ptr2, nodeMap);
	return node;
}

Node* copy_structure(Node* root)
{
	NodeMap nodeMap;
	return copy_recursive(root, nodeMap);
}

void test_137()
{
	Node* root = new Node(1);
	root->ptr1 = new Node(2);
	root->ptr2 = new Node(3);

	Node* copy = copy_structure(root);

	std::cout << *root << std::endl;
	std::cout << *copy << std::endl;
	cout << std::endl;

	root->data = 5;
	std::cout << *root << std::endl;
	std::cout << *copy << std::endl;
}

template<class T> class SmartPointer
{
public:
	SmartPointer(T* ptr)
	{
		ref = ptr;
		ref_count = (unsigned*) malloc(sizeof(unsigned));
		*ref_count = 1;
	}

	SmartPointer(SmartPointer<T> & sptr)
	{
		ref = sptr.ref;
		ref_count = sptr.ref_count;
		++(*ref_count);
	}
	SmartPointer<T> & operator=(SmartPointer<T> & sptr)
	{
		if (*ref_count > 0){
			remove();
		}
		if (this != &sptr)
		{
			ref = sptr.ref;
			ref_count = sptr.ref_count;
			++(*ref_count);
		}
		return *this;
	}
	~SmartPointer()
	{
		remove();
	}

	T getValue()
	{
		return *ref;
	}

protected:
	void remove()
	{
		--(*ref_count);
		if (*ref_count == 0)
		{
			delete ref;
			free(ref_count);
			ref = NULL;
			ref_count = NULL;
		}
	}

	T *ref;
	unsigned *ref_count;
};

class MyClass
{

};

void test_138()
{
	int *cl = new int(10);
	SmartPointer<int> a(cl);
	cout << a.getValue() << endl;
}

void* aligned_malloc(size_t required_bytes, size_t alignment)
{
	void* p1;
	void** p2;
	int offset = alignment - 1 + sizeof(void*);
	if ((p1 = (void*) malloc(required_bytes + offset)) == NULL)
	{
		return NULL;
	}
	p2 = (void**) (((size_t) (p1) + offset) & ~(alignment - 1));
	p2[-1] = p1;
	return p2;
}

void aligned_free(void* p2)
{
	void* p1 = ((void**) p2)[-1];
	free(p1);
}

void test_139()
{
	int alignment = 8;
	int required_bytes = 10;
	
	void * p = (void *) malloc(required_bytes * sizeof(int));
	void * q = aligned_malloc(required_bytes, alignment);
	void * k = aligned_malloc(required_bytes, alignment);

	cout << "p: " << p << endl;
	cout << "q: " << q << endl;
	cout << "k: " << k << endl;

	// aligned_free(p);
//aligned_free(q);
	aligned_free(k);

}

int** my2DAlloc(int rows, int cols)
{
	int** rowptr;	
	rowptr = (int**) malloc(rows*sizeof(int));
	for (int i = 0; i < rows; i++)
	{
		rowptr[i] = (int*) malloc(cols*sizeof(int));
	}
	return rowptr;
}



void my2DDealloc(int** rowptr, int rows)
{
	for (int i = 0; i < rows; i++)
	{
		free(rowptr[i]);
	}
	free(rowptr);
}

int** my2DAlloc1(int rows, int cols)
{
	int header = rows*sizeof(int*);
	int data = rows*cols*sizeof(int);
	int** rowptr = (int**) malloc(header + data);
	if (rowptr == NULL)
	{
		return NULL;
	}
	int* buf = (int*) (rowptr + rows);
	for (int i = 0; i < rows; i++)
	{
		rowptr[i] = buf + i*cols;
	}
	return rowptr;
}

void my2Dealloc1(int** rowptr)
{
	free(rowptr);
}

void test_1310()
{
	int m = 4;
	int n = 5;

	int ** a = my2DAlloc1(m, n);

	for (int i = 0; i < m; ++i) 
	{
		for (int j = 0; j < n; ++j)
		{
			a[i][j] = (i + 1)*(j + 1);
		}
	}

	for (int i = 0; i < m; ++i) 
	{
		for (int j = 0; j < n; ++j)
		{
			cout <<  a[i][j] << " ";
		}
		cout << endl;
	}

	my2Dealloc1(a);
}

int main()
{
	//test_12();
	/*test_137();
	cout << endl;
	test_138();
	test_139();*/
	test_1310();
	return 0;
}