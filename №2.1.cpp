/*�������� �������, ������� ���������� �������� ���� ���������
�������(�� ������ ����� ������� �� 1 �� 6 �����).
(����������� ��������� ��������������� �����.)*/
#include<iostream>
using namespace std;
int main() {
    setlocale(LC_ALL, "Rus");
    int n, m;
    srand(time(0));
    n = 1 + rand() % 6;
    m = 1 + rand() % 6;
    cout << "������ ����� = " << n << endl;
    cout << "������ ����� = " << m << endl;
    return 0;
}