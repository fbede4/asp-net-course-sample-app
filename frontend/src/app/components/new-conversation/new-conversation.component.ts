import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from 'src/app/models/conversation.model';
import { ConversationsService } from 'src/app/services/conversations.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-new-conversation',
  templateUrl: './new-conversation.component.html',
  styleUrls: ['./new-conversation.component.scss'],
})
export class NewConversationComponent implements OnInit {
  selectedUser: User = {
    id: 0,
    name: '',
  };
  users: User[];

  constructor(
    private usersService: UsersService,
    private conversationsService: ConversationsService,
    public dialogRef: MatDialogRef<NewConversationComponent>,
    @Inject(MAT_DIALOG_DATA) public userId: number
  ) {}

  async ngOnInit(): Promise<void> {
    this.users = await this.usersService.getUsers();
    this.users = this.users.filter((u) => u.id !== this.userId);
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  async onOkClick(): Promise<void> {
    await this.conversationsService.createConversation(
      this.userId,
      this.selectedUser.id
    );
    this.dialogRef.close();
  }
}
