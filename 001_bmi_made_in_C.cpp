#include <stdio.h>

int main() {
	double weight, height;

	printf("몸무게(kg)를 입력하세요 : ");
	scanf_s("%lf", &weight);

	printf("키(cm)를 입력하세요 : ");
	scanf_s("%lf", &height);
	
	double bmi = weight / ((height / 100) * (height / 100));
	//double bmi = weight / ((height * 0.01) * (height * 0.01));

	printf("BMI = %.4f\n", bmi);
}