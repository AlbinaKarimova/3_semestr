/*�������� �������, ������� �������� � ����� ����� ���������� �� �������� (��������, �� �.bak�).
������� ��������� ��� ���������: ��� ����� � ����� ����������. ������, ��� � �������� ����� ���������� ����� ���� ������.*/
#include<iostream>
#include<string>
#include<string.h>
using namespace std;
void change_r(char* s, const char* r) {
    const char* s1 = strtok(s, ".");
    while (s1 != NULL) {
        strtok(NULL, ".");
        break;
    }
    strcat(s, r);
    cout << "����� ������ : " << s;
}
int main() {
    const char* r = ".bac";
    char s[256];
    cin >> s;
    change_r(s, r);
    return 0;
}