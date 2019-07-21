#include<stdio.h>
#include<conio.h>
#include<math.h>
typedef struct node
{
	int power;
	float coeff;
	struct node*next;
}node;
node*insert(node*head,int power1,float coeff1);
node*create();
node*padd(node*p1,node*p2);
node*pmul(node*p1,node*P2);
float eval(node*p1,float x);
void print(node*head);
node*insert(node*head,int power1,float coeff1)
{
	node*p,*q;
	p=(node*)malloc(sizeof(node));
	p->power=power1;
	p->coeff=coeff1;
	p->next=NULL;
	if(head==NULL)
	{
		head=p;
		head->next=head;
		return(head);
	}
	if(power1>head->power)
	{
		p->next=head->next;
		head->next=p;
		head=p;
		return(head);
	}
	if(power1==head->power)
	{
		head->coeff=head->coeff+coeff1;
		return(head);
	}
	q=head;
	while(q->next!=head && power1>=q->next->power)
		q=q->next;
	if(p->power==q->power)
		q->coeff=q->coeff+coeff1;
	else
	{
		p->next=q->next;
		q->next=p;
	}
	return(head);
}
node*create()
{
	int n,i,power1;
	float coeff1;
	node*head=NULL;
	printf("\n Enter No. of terms:");
	scanf("%d",&n);
	printf("\nEnter a term as a tuple of(power,coeeficient):");
	for(i=1;i<=n;i++)
	{
		scanf("%d%f",&power1,&coeff1);
		head=insert(head,power1,coeff1);
	}
	return(head);
}
node*padd(node*p1,node*p2)
{
	node*P;
	node*head=NULL;
	int power;
	float coeff;
	p=p1->next;
	do
	{
		head=insert(head,p->power,p->coeff);
		p=p->next;
	}while(p!=p1->next);
	p=p2->next;
	do
	{
		head=insert(head,p->power,p->coeff);
		p=p->next;
	}while(p!=p2->next);
	return(head);
}
node *pmul(node*p1,node*p2)
{
	node*head1,*head2;
	node*head=NULL;
	head2=p2->next;
	do
	{
		head1=p1->next;
		do
		{
			head=insert(head,head1->power+head2->power,head->coeff*head2->coeff);
			head1=head1->next;
		}while(head1!=p1->next);
		return(head);
	}
	float eval(node*head,float x)
	{
		float value=0.00;
		node*p;
		p=head->next;
		do
		{
			value=value+p->coeff*pow(x,p->power);
			p=p->next;
		}while(p!=head->next);
		return(value);
	}
	void print(node*head)
	{
		node*p;
		p=head->next;
		printf("\n");
		do
		{
			printf("%6.2fx^%d",p->power);
			p=p->next;
		}while(p!=head->next);
	}
	void main()
	{
		node *p1,*p2,*p3;
		int op;
		float value,x;
		p1=p2=p3=NULL;
		clrscr();
		do
		{
			printf("\n 1)Create first polynomial");
			printf("\n 2)Create second polynomial");
			printf("\n 3)Print first polynomial");
			printf("\n 4)Print second polynomial");
			printf("\ 5)Add\n 6)Multiply \n 7)Evaluate First Polynomial \n 8)Quit");
			printf("\n Enter Your Choice:");
			scanf("%d",&op);
			switch(op)
			{
			case 1:p1=create();
				break;
			case 2:
				p2=create();
				break;
			case 3:
				print(p1);
				break;
			case 4:
				print(p2);
				break;
			case 5:
				p3=padd(p1,p2);
				print(p3);
				break;
			case 6:
				p3=pmul(p1,p2);
				print(p3);
				break;
			case 7:
				printf("\n Enter the value of X:");
				scanf("%f",&x);
				value=eval(p1,x);
				printf("\nEvaluated value=%6.2f",value);
				break;
			}
		}while(op!=8);
	}
