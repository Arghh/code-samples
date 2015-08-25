#include <stdio.h>
#include <stdlib.h>

//simple string functions in C++

//printtext
void print_text(const char* text)
{
  while (*text)
  {
    printf("%c", *text);
    text++;
  }
}

//get string length
int strlen(const char* input)
{
  int count = 0;
  while(*input)
  {
    input++;
    count++;
  }
  return count;
}

//compare two strings. if equal then what
int strcmp(const char x[], const char y[])
{
  int count = 0;
  while(x[count] == y[count]) 
  {
    if(x[count] == '\0' || y[count] == '\0')
      break;
      count++;    
  }
  return printf("%d\n",count);
}

//copy one string to another string
void strcpy(const char in[], char out[])
{
  for(int i=0; in[i]!='\0'; i++)
    {
        out[i]=in[i];
    }
   printf("%s is now %s \n", in, out);
}


//reverse a string
void strrev(char *x)
{
  for (int i = strlen(x)-1; i >= 0; i--)
  {
    printf("%c", x[i]);
  }
  printf("\n");
}

//add two strings together into second string
void strcat(const char* in, char* out)
{
  int x = strlen(in);
  int y = strlen(out);
  char *a = new char[x + y];
  //first string from 0 to end of first strlen
  for (int i = 0; i < x; i++) 
    {
      a[i] = in[i];
    }
  //secondstr starts from end of first until end of second
  for (int i = x; i < x + y; i++) 
    {
      a[i] = out[i - x];
    }

  a[x + y] = '\0';//determine the end (??)
  printf("%s + %s is %s \n", in, out, a);
}

int main()
{
  char p[100] = "Heiei";
  char a[100] = "World"; 
  char m[100] = "testaram";
  char n[100] = "testarar";

  print_text(p);
  printf("\nString is %d chars long.\n", strlen(p));
  strcmp(m, n);
  strrev(a);
  strcat(a, p);
  strcpy(p, a);
  system("pause");


  return 0;
}
