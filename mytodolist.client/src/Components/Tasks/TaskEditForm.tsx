import ToDoTaskEditDraft from "../../Models/ToDoTaskEditDraft";
import ToDoTaskView from "../../Models/ToDoTaskView"
interface TaskEditFormProps {
    task: ToDoTaskView;
    onSaveChanges(task: ToDoTaskEditDraft): void;
}

const TaskEditForm = ({ task, onSaveChanges }: TaskEditFormProps) => {
    return <><input type="text" value={task.title} onChange={e => task.title = e.target.value } /><button onClick={() => onSaveChanges(task)}>Save</button></>
}

export default TaskEditForm;