// Task2


//problem 1

select p.product_name , s.[year] , s.price
from Sales s inner join Product p
on s.product_id = p.product_id


//problem 2

select v.customer_id , count(*) as no_trans
from Visits v left join Transactions t
on v.visit_id = t.visit_id
where t.transaction_id is null
group by v.customer_id


//problem 3

select e.name , eu.unique_id
from Employee e left join EmployeeUNI eu
on e.id = eu.id


//problem 4

select w1.id
from Weather w1 join Weather w2
on w1.recordDate = DATEADD(day,1,w2.recordDate)
where w1.temperature > w2.temperature


//problem 5

select e.emp_id , coalesce(d.dept_name,"unassigned") as dept_name
from Employee e left join Department d
on e.dept_id = d.dept_id


//problem 6

select p.product_name, s.supplier_name
from Products p left join Suppliers s
on p.supplier_id = s.supplier_id
where p.product_name like 'Phone'


//problem 

select c.first_name+' '+c.last_name as full_name ,o.order_id , o.amount
from Customers c full outer join Orders o
on c.customer_id = o.customer_id


