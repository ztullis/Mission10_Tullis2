export type Bowler = {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerLastName: string;
  bowlerMiddleInit: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
  teamID: number;
  team: Team;
};

export type Team = {
  teamID: number;
  teamName: string;
  captainID: number;
};
