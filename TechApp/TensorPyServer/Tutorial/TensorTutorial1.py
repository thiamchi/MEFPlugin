#%% Prologue
""" 
    this is writing in Jupyter style
    basic 1 : variables, constants and placeholders
"""


#%% In[1] : 
import tensorflow as tf

#%% In[2] : this is a variable **V is capital letter!
zero = tf.Variable(0)

#%% In[3] : this is a constant
one = tf.constant(1)

#%% In[4] :
new_value = tf.add(zero,one)

#%% In[5] : variable value can be changed
update = tf.assign(zero, new_value)

#%% In[6] : constant cannot be changed
#update_constant=tf.assign(one, new_value)
""" AttributeError: 'Tensor' object has no attribute 'assign' """

#%% In[7] : if there is variables, initialize_all_variables()
init_op = tf.global_variables_initializer()

#%% In[8] : create session
sess = tf.Session()

#%% In[9] : run session, initialize variables
sess.run(init_op)

#%% In[10] : run the tensor
print(sess.run(zero))

#%% In[11] : run the tensor
for _ in range(5):
    sess.run(update)
    print(sess.run(zero))

#%% In[12] : string operations
hello = tf.constant("hello")
world = tf.constant("world")
helloworld = tf.add(hello,world)
print(sess.run(helloworld))

#%% In[13] : close session
sess.close()