/*��������� ������ �� N ��������� ���������� ������ ������� � ��������� 1..N ���,
����� � ������ ����������� ����� ��� ����� �� 1 �� N (��������� ��������� ������������).*/
#include<iostream>
using namespace std;

int random_n(int N) {
	return rand() % N + 1;
}

void random_mas(int a[], int size) {
	int N;
	cin >> N;
	for (int i = 0;i < size;i++) {
		a[i] = random_n(N);
	}
}
void print_mas(int a[], int size) {
	for (int i = 0;i < size - 1;i++) {
		cout << a[i] << " ";
	}
	cout << endl;
}

int main() {
	int const N = 20;
	int a[N];
	random_n(N);
	random_mas(a, N);
	print_mas(a, N);
	return 0;
}
