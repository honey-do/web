import React, { Component } from "react";
import TasksList from "../components/Tasks/List";
import TaskForm from "../components/Tasks/Form";
import { Theme, createStyles, withStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import { Task, TaskFormModel, TaskModel } from "../lib/Task";
import { TaskContext } from "../contexts/TaskContext";

const styles = ({ spacing }: Theme) =>
  createStyles({
    button: {
      margin: spacing.unit,
      float: "right"
    },
    buttonContainer: {
      display: "flex",
      flexDirection: "row-reverse"
    }
  });

interface TasksProps {
  classes: { [key: string]: any };
}

interface TasksState {
  isFormOpen: boolean;
  tasks: Task[];
}

const initialState: TasksState = {
  isFormOpen: false,
  tasks: []
};

class Tasks extends Component<TasksProps, TasksState> {
  static contextType = TaskContext;

  constructor(props: TasksProps) {
    super(props);
    this.state = initialState;
  }

  async componentDidMount() {
    const { getTasks } = this.context;
    const tasks = await getTasks();
    this.setState({ tasks });
  }

  handleSave = () => (taskModel: TaskFormModel) => {
    // TODO refactor
    // const { tasks } = this.state;
    // const newTask: Task = {
    //   id: "z",
    //   checked: false,
    //   ...taskModel
    // };
    // this.setState({ tasks: [...tasks, newTask] });
    this.toggleForm();
  };

  toggleForm = () => {
    const isFormOpen = !this.state.isFormOpen;
    this.setState({ isFormOpen });
  };

  handleTaskUpdate = (task: Task) => {
    const { tasks } = this.state;
    const taskIndex = tasks.findIndex(tsk => tsk.id === task.id);
    const updateTasks: Task[] = [
      ...tasks.slice(0, taskIndex),
      task,
      ...tasks.slice(taskIndex + 1)
    ];
    this.setState({ tasks: updateTasks });
  };

  render() {
    const { classes } = this.props;
    const { isFormOpen, tasks } = this.state;
    return (
      <div>
        <TasksList
          tasks={tasks}
          handleUpdate={task => this.handleTaskUpdate(task)}
        />
        {!isFormOpen ? (
          <div className={classes.buttonContainer}>
            <Button
              className={classes.button}
              onClick={() => this.toggleForm()}>
              Add Task
            </Button>
          </div>
        ) : (
          <TaskForm
            onCancel={() => this.toggleForm()}
            onSave={this.handleSave()}
          />
        )}
      </div>
    );
  }
}

export default withStyles(styles)(Tasks);
