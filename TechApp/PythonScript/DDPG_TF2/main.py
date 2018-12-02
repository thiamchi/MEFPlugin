# Main
from env import ArmEnv
from rl import DDPG
import random

MAX_EPISODES = 300
MAX_EP_STEPS = 200
ON_TRAIN = True

# set env
env = ArmEnv()
env.get_train_state = ON_TRAIN
s_dim = env.state_dim
a_dim = env.action_dim
a_bound = env.action_bound

# set RL method (continuous)
rl = DDPG(a_dim, s_dim, a_bound)
rl.get_train_state = ON_TRAIN

def train():
    # start training
    sample_goal = [None]*36
    for incx in range(6):
        for incy in range(6):
            sample_goal[incy*6 + incx] = {'x': (100. + incx*40), 'y': (100. + incy*40), 'l': 40}
    print(len(sample_goal))
    for i in range(MAX_EPISODES):
        sample_goal = random.sample(sample_goal,len(sample_goal));
        goal_num = 0
        for goal in sample_goal:
            env.goal = goal
            s = env.reset()
            ep_r = 0.
            goal_num += 1
            for j in range(MAX_EP_STEPS):
                env.render()

                a = rl.choose_action(s)

                s_, r, done = env.step(a)

                rl.store_transition(s, a, r, s_)

                ep_r += r
                if rl.memory_full:
                    # start to learn once has fulfilled the memory
                    rl.learn()

                s = s_
                if done or j == MAX_EP_STEPS-1:
                    print('Ep: %i | Goal: %i| %s | ep_r: %.1f | steps: %i' % (i, goal_num, '---' if not done else 'done', ep_r, j))
                    break
    rl.save()


def eval():
    rl.restore()
    env.render()
    env.viewer.set_vsync(False)
    s = env.reset()
    while True:
        env.render()
        a = rl.choose_action(s)
        s, r, done = env.step(a)

if ON_TRAIN:
    train()
else:
    eval()

# summary:
"""
env should have at least:
env.reset()
env.render()
env.step()
while RL should have at least:
rl.choose_action()
rl.store_transition()
rl.learn()
rl.memory_full
"""