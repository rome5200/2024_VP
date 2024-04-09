#include <iostream>
using namespace std;

int main() {
	double weight, height;

	cout << "체중(kg)을 입력하세요 : ";
	cin >> weight;
	cout << "키(cm)를 입력하세요 : ";
	cin >> height;

	double bmi = weight / ((height / 100) * (height / 100));

	cout << "BMI = " << bmi << endl;
}