
// Task 3

// Problem 8
create index idx_customerOrders
on Orders (order_date)
include (order_id, customer_id, total_amount)


// Problem 9
create proc sp_ApplyCategoryDiscount
    @CatID int,                   
    @DiscountPercent decimal(5,2) 
as
    update Products
    set price =case
                   when price * (1 - @DiscountPercent / 100) < min_price  then min_price         
                   else price * (1 - @DiscountPercent / 100) 
                end
    where category_id = @CatID



// Problem 10
create view v_VIPCustomers
as
  Select C.name, C.email, Sum(O.total_amount) total_spent
  from Customer C join Order O
  on C.customer_id = O.customer_id
  group by C.name , C.email
  having  Sum(O.total_amount) > 5000