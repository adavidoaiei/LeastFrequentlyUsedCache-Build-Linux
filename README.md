# Least Frequently Used Cache

A Least Frequently Cache algorithm implementation which has logarithmic complexity, it's using a binary tree where nodes are linked list of cached elements with the same use count, this binary tree sorts this linked lists by use count.

<b>Performance benchmark</b><br>

1000.000 add/get operations using elements from a list with 100.000 in a LFU Cache of size 90.000 in 411ms
<img src="https://lh3.googleusercontent.com/SJyPHpSQyt_7e4yCI2zQaac8mzHRAEmmIfsh8DyHRWCxVe1CA88o6sR3exQ7TiJpTi5kWVXmvGa5EbCuRJuN4Oog1yaQuKsjB8OYZKHHH0H_hTB6w34aUiT_itgTBWwM2xBfGpRSl3DnCs9qehqIQHHlSukbY_MSQeS39WcpN2lp1lqSmmHqtPIUS-KXGriHCXc1cm3Hi6ynDIln3LHp6upelUddBlBNgxaepprF5vmpN8PFqkMhTcTxdx3H8dodioikMKlZlMKyV4o7ZeZae6S-RnUTqkeENQu7BfuJpqk7WURfPfhnGTQiwXQJlwEB2BBvpO6BzmmQixmS8hxaP_EPcNlcEvdK5fYXng-06EudN7lXcGGE_JMqYGV_2pSKQbznLGlSLBQeTnp40H4Vg7lCgIycK-j8SsIVkptkZ6VpReffUXfNNYRQQQy2gmBJUm6-Wrdvmv9iYTGg9gxBcn9uWWDYo5RfaPRrBZxJ5s6bMcQNd4wtxi1DftcrvcsLh-W1yGoMrvlngiNh9bnBHvop2QOPRr_irTLOs7P8ELgMvWY0TGsoOvebezIxor9ikSkCH12L_Amv0I4dKD5PUAZdeTX52dI=w1079-h211-no" />

